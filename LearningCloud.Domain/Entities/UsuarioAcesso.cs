using System;

namespace LearningCloud.Domain.Entities
{
    public class UsuarioAcesso
    {
        public virtual string uac_id { get; set; }
        public virtual string uac_email { get; set; }
        public virtual bool uac_emailConfirmed { get; set; }
        public virtual string uac_passwordHash { get; set; }
        public virtual string uac_securityStamp { get; set; }
        public virtual string uac_phoneNumber { get; set; }
        public virtual bool uac_phoneNumberConfirmed { get; set; }
        public virtual bool uac_twoFactorEnabled { get; set; }
        public virtual DateTime? uac_lockoutEndDateUtc { get; set; }
        public virtual bool uac_lockoutEnabled { get; set; }
        public virtual int uac_accessFailedCount { get; set; }
        public virtual string uac_userName { get; set; }
        public virtual Usuario uac_usuario { get; set; }
    }
}
