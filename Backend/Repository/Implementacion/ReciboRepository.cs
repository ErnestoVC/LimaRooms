using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.dbcontext;
using Repository.ViewModel;

namespace Repository
{
    public class ReciboRepository : IReciboRepository
    {
        private ApplicationDbContext context;
        public ReciboRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Recibo Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recibo> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReciboViewModel> GetAllRecibos()
        { 
            var recibo = context.Recibos
                .Include(o=>o.Cliente)
                .OrderByDescending(o=>o.Id)
                .Take(10)
                .ToList();

            return recibo.Select(o=> new ReciboViewModel {
                        Id = o.Id,
                        NroRecibo = o.NroRecibo,
                        Total = o.Total,
                        NombreCliente = o.Cliente.nombre
            });
        }

        public IEnumerable<DetalleReciboViewModel> ListarDetalles(int reciboId)
        {
            var detalle = context.DetealleRecibos
                .Include(m=>m.Inmobiliario)
                .Where(d=>d.ReciboId == reciboId)
                .ToList();
            
            return detalle.Select(d=> new DetalleReciboViewModel {
                InmobiliarioId = d.InmobiliarioId,
                NombreInmobiliario = d.Inmobiliario.nombre,
                mes = d.mes,
                adicional = d.adicional
            });
        }

        public bool Save(Recibo e)
        {
            Recibo recibo = new Recibo{
                ClienteId = e.ClienteId,
                NroRecibo = e.NroRecibo,
                Total = e.Total                
            };

            try
            {
                context.Recibos.Add(recibo);
                context.SaveChanges();
                var reciboId = recibo.Id;
                foreach(var item in e.DetalleRecibo){
                    DetalleRecibo detalle = new DetalleRecibo{
                        ReciboId = reciboId,
                        InmobiliarioId = item.InmobiliarioId,
                        mes = item.mes,
                        adicional = item.adicional
                    };
                    context.DetealleRecibos.Add(detalle);
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Recibo e)
        {
            throw new System.NotImplementedException();
        }
    }
}