using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.DomainModel;

namespace WalkerCRM.Domain
{
    public class User : Entity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空。")]
        public virtual string UserName { get; set; }
    }
}