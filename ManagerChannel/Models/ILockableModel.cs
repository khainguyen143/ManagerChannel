using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{

    /// <summary>
    /// Lock enttiy lại tạm thời không cho thay đổi/xóa
    /// Trong một số TH cần lock lại:
    /// - Chạy background service với thời gian thực thi dài mà có dùng data của entity để xử lý
    ///     => Nếu service đang thực thi dở, mà người dùng xóa/sửa dữ liệu eneity => có thể dẫn tới lỗi.
    /// - Admin muốn lock lại không có user sửa xóa dữ liệu
    /// </summary>
    public interface ILockableModel
    {
        public bool IsLocked { get; set; }
    }
}
