using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Repository.dbcontext;

namespace Repository.Implementacion
{
    public class ClienteRepository : IClienteRepository
    {
        private ApplicationDbContext context;
        
        public ClienteRepository(ApplicationDbContext context){
            this.context=context;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = new Cliente();
                result = context.Clientes.Single(x=>x.Id == id);
                context.Remove(result);
                context.SaveChanges();
            }
            catch(Exception){
                return false;
            }
            return true;
        }

        public IEnumerable fetchClienteByDni(string dni)
        {
            var result = new List<Cliente>();
            try{
                result = context.Clientes.Where(m=>m.nroDocumento.Contains(dni)).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable fetchClienteByNombre(string nombre)
        {
            var result = new List<Cliente>();
            try{
                result = context.Clientes.Where(m=>m.nombre.Contains(nombre)).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public Cliente Get(int id)
        {
            var result = new Cliente();
            try{
                result = context.Clientes.Single(x=>x.Id == id);
            }
            catch(Exception){
                throw;
            }
            return result;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();
            try{
                result = context.Clientes.ToList();
            }
            catch(Exception){
                throw;
            }
            return result;
        }

        public bool Save(Cliente e)
        {
            var result = new List<Cliente>();
            result = context.Clientes.Where(x=>x.nroDocumento == e.nroDocumento).ToList();
            if(result.Count == 0){
                try{
                    context.Add(e);
                    context.SaveChanges();
                }
                catch(Exception){
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool Update(Cliente e)
        {
            var result = new List<Cliente>();
            result = context.Clientes.Where(x=>x.nroDocumento == e.nroDocumento).ToList();
            if(result.Count == 0){
                try{
                    var original = context.Clientes.Single(x=>x.Id==e.Id);

                    original.Id = e.Id;
                    original.nombre = e.nombre;
                    original.apellidos = e.apellidos;
                    original.nacionalidad = e.nacionalidad;
                    original.telefono = e.telefono;
                    original.correo = e.correo;
                    original.tipoDocumento = e.tipoDocumento;
                    original.nroDocumento = e.nroDocumento;

                    context.Update(original);
                    context.SaveChanges();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}