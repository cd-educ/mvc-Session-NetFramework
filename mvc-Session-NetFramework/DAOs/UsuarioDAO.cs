﻿using mvc_Session_NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Session_NetFramework.DAOs
{
    public class UsuarioDAO
    {

        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null){
                instancia = new UsuarioDAO();
            }

            return instancia;

        }

        public UsuarioDAO add(Usuario user)
        {
            usuarios.Add(user);
            return this;
        }

        public Usuario buscarUsuario(string username, string password){
            return usuarios.Find(x => x.username == username && x.password == password);
        }


    }
}