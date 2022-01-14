using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        
        public Serie(int id, Genero genero, string titulo, string descricao, int ano) // Metodo construtor Serie
        {
            this.Id = id; // this (= isto): refere-se à instância atual da classe e também é usada como um modificador do primeiro parâmetro de um método de extensão.
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        
        // Criação do metodo ToString (sobrepor) retornar uma cadeia de caracteres que representa o objeto atual
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine; // O Environment.NewLine significa ambiente e pega como o sistema interpreta uma nova linha
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "*Excluido*: " + this.Excluido;
            return retorno;
        }

        // Encapsulamento 
        // Criação método que retorna título e retorna Id (vai ser usado quando formos listar uma série)
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        
        public int retornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}