using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagosti.TamagostiModel
{
    public class TamagostiModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Felicidade { get; private set; } = 100;
        public int Saciedade { get; private set; } = 100;
        public int Energia {  get; private set; } = 100;

        public void Brincar(TamagostiModel tamagosti, int quantidadeDeFelicidade)
        {
            Felicidade += quantidadeDeFelicidade;
            Saciedade -= quantidadeDeFelicidade;
            Energia -= quantidadeDeFelicidade;
        }
        public void Alimentar(TamagostiModel tamagosti, int quantidadeDeComida)
        {
            Saciedade += quantidadeDeComida;
            Energia -= quantidadeDeComida;
            Felicidade -= quantidadeDeComida;
        }
        public void Dormir(TamagostiModel tamagosti, int tempoDeSono)
        {
            Energia += tempoDeSono;
            Saciedade -= tempoDeSono;
            Felicidade -= tempoDeSono;
        }

    }
}
