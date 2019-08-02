using System;

namespace System.BLog.DTO
{
    public class UserDto:BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Portrait { get; set; }
        public int FansCount { get; set; }
    }
}
