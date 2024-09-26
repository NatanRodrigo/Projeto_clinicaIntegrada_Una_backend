using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services.Interfaces
{
    public interface IGeracaoUsuariosPerfisIniciais
    {
        void GerarUsuarios();
        void GerarPerfis();
    }
}
