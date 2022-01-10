using AutoMapper;
using ManagerChannel.Data;
using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Dto.TeamDtos;
using ManagerChannel.Interfaces;
using ManagerChannel.Models.Teams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ManagerChannel.Dto.TeamDtos.FilterTeamDto;

namespace ManagerChannel.Controllers.TeamManagement
{
    [Route("api/v1/team")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TeamsController(ILogger logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> GetAsync(string teamId)
        {
            try
            {
                if (string.IsNullOrEmpty(teamId))
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "Dữ liệu đầu vào không hợp lệ."));
                }

                var team = _context.Teams
                    .Include(entity => entity.ParentTeam)
                    .Include(entity => entity.SubTeams)
                    .Include(entity => entity.UserRolesInTeam).ThenInclude(entity => entity.UserRole_YoutubeChannels)
                    .Include(entity => entity.CreatedByUser)
                    .Include(entity => entity.UpdatedByUser)
                    .FirstOrDefault(entity => entity.Id == teamId);
                if (team == null)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "Dữ liệu đầu vào không hợp lệ."));
                }

                var dto = ConvertEntityToDto(team);

                return Ok(dto);
            }
            catch(Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { TeamId = teamId });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> FilterAsync(FilterTeamDto filterDto)
        {
            try
            {
                _context.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var query = _context.Teams.Include(entity => entity.ParentTeam)
                    .Include(entity => entity.SubTeams)
                    .AsQueryable();

                query = filterDto.CreateBaseQuery(query);


                var responseBody = await PaginatedListDto<Team, TeamDto>.CreateAsync(query, filterDto.PageIndex, filterDto.PageSize, ConvertEntityToDto);
                return Ok(responseBody);

            }
            catch(Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Dto = filterDto });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddAsync(AddTeamDto addDto)
        {
            try
            {
                if (addDto != null)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "Dữ liệu đầu vào không hợp lệ."));
                }

                var validateResult = addDto.Validate();
                if (!validateResult.IsSuccess)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, validateResult.ErrorMessage));
                }
                _context.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var team = new Team();
                team = ConvertAddDtoToEntity(addDto);
                 _context.Teams.Add(team);
                await _context.SaveChangesAsync();

                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Dto = addDto });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditAsync(EditTeamDto editDto)
        {
            try
            {
                if (editDto != null)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "Dữ liệu đầu vào không hợp lệ."));
                }

                var validateResult = editDto.Validate();
                if (!validateResult.IsSuccess)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, validateResult.ErrorMessage));
                }
                _context.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var team = _context.Teams
                    .Include(entity => entity.ParentTeam)
                    .Include(entity => entity.SubTeams)
                    .Include(entity => entity.UserRolesInTeam).ThenInclude(entity => entity.UserRole_YoutubeChannels)
                    .Include(entity => entity.CreatedByUser)
                    .Include(entity => entity.UpdatedByUser)
                    .FirstOrDefault(entity => entity.Id == editDto.Id);

                if(team == null)
                {
                    return NotFound(new ResponseMessageDto(MessageType.Warning, "Không tìm thấy Team bạn muốn chỉnh sửa."));
                }    

                team = _mapper.Map<Team>(editDto);

                return Ok(new ResponseMessageDto(MessageType.Success, "Chỉnh sửa thông tin nhóm thành công."));
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Dto = editDto });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpDelete]
        [Route("delete/{teamId}")]
        public async Task<IActionResult> DeleteAsync(string teamId)
        {
            try
            {
                if(string.IsNullOrEmpty(teamId))
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "Dữ liệu đầu vào không hợp lệ."));
                }

                _context.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var team = _context.Teams
                    .Include(entity => entity.ParentTeam)
                    .Include(entity => entity.SubTeams)
                    .Include(entity => entity.UserRolesInTeam).ThenInclude(entity => entity.Role)
                    .Include(entity => entity.CreatedByUser)
                    .Include(entity => entity.UpdatedByUser)
                    .FirstOrDefault(entity => entity.Id == teamId);
                if (team == null)
                {
                    return NotFound(new ResponseMessageDto(MessageType.Warning, "Không tìm thấy Team bạn muốn chỉnh sửa."));
                }
                var parentRoleInTeam = team.UserRolesInTeam.Where( e => e.UserId == _context.UserId && e.TeamId == teamId).ToList();
                if(parentRoleInTeam.Count <= 0)
                {
                    return Ok(new ResponseMessageDto(MessageType.Warning, "Bạn không có quyền đối với nhóm này."));
                }

                var userInTeam = _context.UserRoleInTeams.Where(entity => entity.TeamId == teamId).ToList();
                if(userInTeam.Count > 0)
                {
                    return NotFound(new ResponseMessageDto(MessageType.Warning, "Bạn cần xóa các người dùng thuộc nhóm này"));
                }    
                team.IsDeleted = true;
                team.DeletedByUserId = _context.UserId;
                team.DeletedDate = DateTime.Now;
                _context.Teams.Update(team);
                var count =  await _context.SaveChangesAsync();
                if(count > 0)
                {
                    return Ok(new ResponseMessageDto(MessageType.Success, "Xóa dữ liệu thành công."));
                }   
                else
                {
                    return Ok(new ResponseMessageDto(MessageType.Warning, "Không có dữ liệu nào được xóa."));
                }    

            }
            catch(Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Id = teamId });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        public Team ConvertAddDtoToEntity (AddTeamDto dto)
        {
            try
            {
                var team = _mapper.Map<Team>(dto);
                return team;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                return null;
            }
        }

        public TeamDto ConvertEntityToDto(Team entity)
        {
            try
            {
                var dto = _mapper.Map<TeamDto>(entity);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                return null;
            }
        }
    }
}
