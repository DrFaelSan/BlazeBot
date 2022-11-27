

namespace BlazeBot.Dto
{
    public class EstatisticasDto
    {
        //1
        public double preto { get; set; }
        public double vermelho { get; set; }
        public double verde { get; set; }

        //2
        public double baixo { get; set; }
        public double alto { get; set; }

        //3
        public double par { get; set; }
        public double impar { get; set; }

        //4
        public double primeiraCol { get; set; }
        public double segundaCol { get; set; }
        public double terceiraCol { get; set; }

        //5
        public double primeiraDuz { get; set; }
        public double segundaDuz { get; set; }
        public double terceiraDuz { get; set; }

        //6
        public double tier { get; set; }
        public double orfans { get; set; }
        public double vorsis { get; set; }
        public double zero { get; set; }

        public EstatisticasDto()
        {

        }

        public void Abastecer(double preto, double vermelho, double verde, double baixo, double alto, double par,
            double impar, double primeiraCol, double segundaCol, double terceiraCol, double primeiraDuz, double segundaDuz, double terceiraDuz,
            double tier, double orfans, double vorsis, double zero)
        {
            this.preto += preto;
            this.vermelho += vermelho;
            this.verde += verde;
            this.baixo += baixo;
            this.alto += alto;
            this.par += par;
            this.impar += impar;
            this.primeiraCol += primeiraCol;
            this.segundaCol += segundaCol;
            this.terceiraCol += terceiraCol;
            this.primeiraDuz += primeiraDuz;
            this.segundaDuz += segundaDuz;
            this.terceiraDuz += terceiraDuz;
            this.tier += tier;
            this.orfans += orfans;
            this.vorsis += vorsis;
            this.zero += zero;
        }
         
        public void MediaPonderada() {
            preto /= 4;
            vermelho /= 4;
            verde /= 4;
            baixo /= 4;
            alto /= 4;
            par /= 4;
            impar /= 4;
            primeiraCol /= 4;    
            segundaCol /= 4;    
            terceiraCol /= 4;
            primeiraDuz /= 4;
            segundaDuz /= 4;
            terceiraDuz /= 4;
            tier /= 4;
            orfans /= 4;
            vorsis /= 4;
            zero /= 4;
        }

        public string Cores() 
            =>  preto > vermelho ? "preto" : "vermelho";
        
        public string BaixoAlto() 
            =>  alto > baixo? "alto" : "baixo";

        public string parImpar()
            => par > impar ? "par" : "impar";

        public IReadOnlyList<string> Colunas() {
            List<double> valores = new List<double> { primeiraCol, segundaCol, terceiraCol };
            List<string> valoresResultantes = new List<string>(); 

            if (primeiraCol == valores.Max() || primeiraCol == valores.Min())
                valoresResultantes.Add("primeiraCol");
            if (segundaCol == valores.Max() || segundaCol == valores.Min())
                valoresResultantes.Add("segundaCol");
            if (terceiraCol == valores.Max() || terceiraCol == valores.Min())
                valoresResultantes.Add("terceiraCol"); 

            return valoresResultantes;
        }

        public IReadOnlyList<string> Duzias()
        {
            List<double> valores = new List<double> { primeiraDuz, segundaDuz, terceiraDuz};
            List<string> valoresResultantes = new List<string>();

            if (primeiraDuz == valores.Max() || primeiraDuz == valores.Min())
                valoresResultantes.Add("primeiraDuz");
            if (segundaDuz == valores.Max() || segundaDuz == valores.Min())
                valoresResultantes.Add("segundaDuz");
            if (terceiraDuz == valores.Max() || terceiraDuz == valores.Min())
                valoresResultantes.Add("terceiraDuz");

            return valoresResultantes;
        }

        public IReadOnlyList<string> LugareNaMesa()
        {
            List<double> valores = new List<double> { tier, orfans, vorsis, zero};
            List<string> valoresResultantes = new List<string>();

            if (tier == valores.Max() || tier == valores.Min())
                valoresResultantes.Add("tier");
            if (orfans == valores.Max() || orfans == valores.Min())
                valoresResultantes.Add("orfans");
            if (vorsis == valores.Max() || vorsis == valores.Min())
                valoresResultantes.Add("vorsis");
            if (zero == valores.Max() || zero == valores.Min())
                valoresResultantes.Add("zero");

            return valoresResultantes;
        }
    }
}
