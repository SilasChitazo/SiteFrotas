using System.Data;
using System.Data.OleDb;
using System.IO;

namespace SiteFrotas.Data
{
    public static class DatabaseHelper
    {
        private static readonly string caminhoBanco =
Path.Combine(Directory.GetCurrentDirectory(), "FrotasAppDB.accdb"); public static string ConnectionString =>
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={caminhoBanco};";
        public static OleDbConnection ObterConexao()
        {
            var conexao = new OleDbConnection(ConnectionString);
            conexao.Open();
            return conexao;
        }
        public static void Inicializar()
        {
            using var conexao = ObterConexao();
            CriarTabelaSeNaoExistir(conexao, "Veiculos", @"
 CREATE TABLE Veiculos (
 Id AUTOINCREMENT PRIMARY KEY,
 Matricula TEXT(20), Marca TEXT(50), Modelo TEXT(50),
 Ano INTEGER, Quilometragem INTEGER)");

            CriarTabelaSeNaoExistir(conexao, "Motoristas", @"
 CREATE TABLE Motoristas (
 Id AUTOINCREMENT PRIMARY KEY,
 Nome TEXT(100), NumeroCarta TEXT(30), Telefone TEXT(30))");

            CriarTabelaSeNaoExistir(conexao, "Abastecimentos", @"
 CREATE TABLE Abastecimentos (
 Id AUTOINCREMENT PRIMARY KEY,
 VeiculoId INTEGER, Data TEXT(20), Litros DOUBLE,
 ValorTotal DOUBLE, Quilometragem INTEGER)");

            CriarTabelaSeNaoExistir(conexao, "Viagens", @"
 CREATE TABLE Viagens (
 Id AUTOINCREMENT PRIMARY KEY,
 VeiculoId INTEGER, MotoristaId INTEGER, Origem TEXT(100),
 Destino TEXT(100), DataSaida TEXT(20), DataChegada TEXT(20),
 KmInicial INTEGER, KmFinal INTEGER)");
        }
        private static void CriarTabelaSeNaoExistir(OleDbConnection conexao, string nomeTabela, string sqlCriacao) {
            var tabelas = conexao.GetSchema("Tables");
            foreach (DataRow linha in tabelas.Rows)
                if (linha["TABLE_NAME"].ToString() == nomeTabela) return;
            using var comando = conexao.CreateCommand();
            comando.CommandText = sqlCriacao;
            comando.ExecuteNonQuery();
        }
    }
}