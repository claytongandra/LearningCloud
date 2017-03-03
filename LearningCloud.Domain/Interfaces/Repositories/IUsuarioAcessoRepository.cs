using System;
using System.Collections.Generic;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Domain.Interfaces.Repositories
{
    public interface IUsuarioAcessoRepository : IDisposable
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
