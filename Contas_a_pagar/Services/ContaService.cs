using Contas_a_pagar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas_a_pagar.Services
{
    public class ContaService : IContaService
    {
        private readonly ApiDbContext _context;

        public ContaService(ApiDbContext context)
        {
            _context = context;
        }

        public Conta CalcularJuros(Conta conta)
        {
            var quantidadeDiasAtraso = (conta.DataPagamento - conta.DataVencimento).Days;

            if (quantidadeDiasAtraso >= 1 && quantidadeDiasAtraso <= 3)
            {
                conta.Multa = 0.02m;
                conta.Juros = 0.01m;

                var calculoMulta = conta.ValorOriginal * conta.Multa;
                var calculoJuros = conta.ValorOriginal * conta.Juros;

                conta.ValorCorrigido = conta.ValorOriginal + calculoMulta + (calculoJuros * quantidadeDiasAtraso);
            }
            else if (quantidadeDiasAtraso >= 4 && quantidadeDiasAtraso <= 5)
            {
                conta.Multa = 0.03m;
                conta.Juros = 0.02m;

                var calculoMulta = conta.ValorOriginal * conta.Multa;
                var calculoJuros = conta.ValorOriginal * conta.Juros;

                conta.ValorCorrigido = conta.ValorOriginal + calculoMulta + (calculoJuros * quantidadeDiasAtraso);
            }
            else if (quantidadeDiasAtraso > 5) 
            {
                conta.Multa = 0.05m;
                conta.Juros = 0.03m;

                var calculoMulta = conta.ValorOriginal * conta.Multa;
                var calculoJuros = conta.ValorOriginal * conta.Juros;

                conta.ValorCorrigido = conta.ValorOriginal + calculoMulta + (calculoJuros * quantidadeDiasAtraso);
            }

            conta.QuantidadeDiasAtraso = quantidadeDiasAtraso;

            return conta;
        }

        public void InserirConta(Conta conta)
        {
            try
            {
                CalcularJuros(conta);

                _context.Contas.Add(conta);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public List<Conta> ListarContas()
        {
            try
            {
                return _context.Contas.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public interface IContaService
    {
        Conta CalcularJuros(Conta conta);
        void InserirConta(Conta conta);
        List<Conta> ListarContas();
    }
}
