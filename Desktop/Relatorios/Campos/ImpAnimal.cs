namespace Desktop.Relatorios.Campos
{
    public class ImpAnimal
    {
        public string Identificacao { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Peso { get; set; }
        public string Castrado { get; set; }
        public string Deficiencia { get; set; }
        public string Genero { get; set; }
        public string Status { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public string Especie { get; set; }
        public string Porte { get; set; }
        public string DataRecolhimento { get; set; }
        public string Recolhedor { get; set; }
        public string Observacao { get; set; }
        public string MotivoRecolhimento { get; set; }
        public string DataFalecimento { get; set; }
        public string MotivoFalecimento { get; set; }

        public static ImpAnimal GetCabecalho()
        {
            var titlulo = new ImpAnimal()
            {
                Identificacao = "Identificação",
                Nome = "Nome",
                DataNascimento = "Data nascimento",
                Peso = "Peso",
                Castrado = "Castrado",
                Deficiencia = "Possui deficiência",
                Genero = "Gênero",
                Status = "Status",
                Raca = "Raça",
                Cor = "Cor",
                Especie = "Espécie",
                Porte = "Porte",
                DataRecolhimento = "Data recolhimento",
                MotivoRecolhimento = "Motivo recolhimento",
                Recolhedor = "Recolhedor",
                Observacao = "Observação",
                DataFalecimento = "Data falecimento",
                MotivoFalecimento = "Motivo falecimento"
            };

            return titlulo;
        }
    }
}
