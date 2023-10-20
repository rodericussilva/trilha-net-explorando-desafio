using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade) // Verifica a capacidade da Suite
            {
                Hospedes = hospedes;
                Console.WriteLine("Hospedagem válida!");
            }
            else
            {
                // Retornar uma exceção caso a capacidade seja menor que o número de hóspedes recebido
                throw new ArgumentException("A quantidade de hóspedes é maior que a capacidade!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count; // Retorna o número de hóspedes na lista.
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria; // Cálculo da diária

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica um desconto de 10%
            }

            return valor;
        }
    }
}