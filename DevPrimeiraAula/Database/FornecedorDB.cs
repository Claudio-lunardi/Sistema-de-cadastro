//using DevPrimeiraAula.Models;
//using System;
//using System.Data.SqlClient;


//namespace DevPrimeiraAula.Database
//{
//    internal class FornecedorDB
//    {
//        private readonly SqlConnection connection;

//        public FornecedorDB()
//        {
//            connection = ConexaoSqlServer.Conectar();
//        }

//        internal void Inserir(FornecedorModel FornecedorModelo)
//        {
//            try
//            {
//                string queryString = "INSERT INTO  Fornecedores VALUES (@CNPJ, @Nome, @Telefone,@Logradouro,@Numero,@Complemento,@Cidade,@Estado,@DataInclusao,@DataAlteracao,@Ativo)";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@CNPJ", FornecedorModelo.CNPJ);
//                command.Parameters.AddWithValue("@Nome", FornecedorModelo.Nome);
//                command.Parameters.AddWithValue("@Telefone", FornecedorModelo.Telefone ?? (object)DBNull.Value);

//                command.Parameters.AddWithValue("@Logradouro", FornecedorModelo.Logradouro);
//                command.Parameters.AddWithValue("@Numero", FornecedorModelo.Numero);
//                command.Parameters.AddWithValue("@Complemento", FornecedorModelo.Complemento ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Cidade", FornecedorModelo.Cidade);
//                command.Parameters.AddWithValue("@Estado", FornecedorModelo.Estado);

//                command.Parameters.AddWithValue("@DataInclusao", DateTime.Now);
//                command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", FornecedorModelo.Ativo);

//                connection.Open();
//                command.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Erro ao incluir o cliente - " + ex.Message);
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }


//        }



//        internal FornecedorModel ObterDadosFornecedor(string cnpjDigitado)
//        {
//            FornecedorModel modelo = new FornecedorModel();
//            try
//            {
//                string queryString = "SELECT * FROM Fornecedores Where CNPJ = @CNPJ";
//                SqlCommand command = new SqlCommand(queryString, connection);
//                command.Parameters.AddWithValue("@CNPJ", cnpjDigitado);
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    modelo.CNPJ = reader["CNPJ"].ToString();
//                    modelo.Nome = reader["Nome"].ToString();
//                    modelo.Telefone = reader["Telefone"].ToString();
//                    modelo.Logradouro = reader["Logradouro"].ToString();
//                    modelo.Numero = reader["Numero"].ToString();
//                    modelo.Complemento = reader["Complemento"].ToString();
//                    modelo.Cidade = reader["Cidade"].ToString();
//                    modelo.Estado = reader["Estado"].ToString();
//                    modelo.DataInclusao = Convert.ToDateTime(reader["DataInclusao"].ToString());
//                    modelo.DataAlteracao = Convert.ToDateTime(reader["DataAlteracao"].ToString());
//                    modelo.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
//                }
//                reader.Close();
//                connection.Close();
//                connection.Dispose();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }
//            return modelo;

//        }





//        internal void Alterar(FornecedorModel FornecedorModelo)
//        {
//            try
//            {
//                string queryString = "UPDATE Fornecedores set  Nome = @Nome,Telefone = @Telefone, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao, Ativo = @Ativo WHERE CNPJ = @CNPJ";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@CNPJ", FornecedorModelo.CNPJ);
//                command.Parameters.AddWithValue("@Nome", FornecedorModelo.Nome);
//                command.Parameters.AddWithValue("@Telefone", FornecedorModelo.Telefone ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Logradouro", FornecedorModelo.Logradouro);
//                command.Parameters.AddWithValue("@Numero", FornecedorModelo.Numero);
//                command.Parameters.AddWithValue("@Complemento", FornecedorModelo.Complemento ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Cidade", FornecedorModelo.Cidade);
//                command.Parameters.AddWithValue("@Estado", FornecedorModelo.Estado);
//                command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", FornecedorModelo.Ativo);

//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//            catch (Exception)
//            {
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }
//        }
//        internal List<FornecedorModel> ObterTodosFornecedor()
//        {
//            List<FornecedorModel> lFornecedorModel = new List<FornecedorModel>();

//            try
//            {
//                FornecedorModel FornecedorModel;

//                string queryString = "SELECT * FROM Fornecedores";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                connection.Open();

//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    FornecedorModel = new FornecedorModel();

//                    if (!reader["CNPJ"].Equals(DBNull.Value)) FornecedorModel.CNPJ = (String)reader["CNPJ"];
//                    if (!reader["Nome"].Equals(DBNull.Value)) FornecedorModel.Nome = (String)reader["Nome"];
//                    if (!reader["Telefone"].Equals(DBNull.Value)) FornecedorModel.Telefone = (String)reader["Telefone"];
//                    if (!reader["Logradouro"].Equals(DBNull.Value)) FornecedorModel.Logradouro = (String)reader["Logradouro"];
//                    if (!reader["Numero"].Equals(DBNull.Value)) FornecedorModel.Numero = (String)reader["Numero"];
//                    if (!reader["Complemento"].Equals(DBNull.Value)) FornecedorModel.Complemento = (String)reader["Complemento"];
//                    if (!reader["Cidade"].Equals(DBNull.Value)) FornecedorModel.Cidade = (String)reader["Cidade"];
//                    if (!reader["Estado"].Equals(DBNull.Value)) FornecedorModel.Estado = (String)reader["Estado"];
//                    if (!reader["DataInclusao"].Equals(DBNull.Value)) FornecedorModel.DataInclusao = (DateTime)reader["DataInclusao"];
//                    if (!reader["DataAlteracao"].Equals(DBNull.Value)) FornecedorModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
//                    if (!reader["Ativo"].Equals(DBNull.Value)) FornecedorModel.Ativo = (bool)reader["Ativo"];

//                    lFornecedorModel.Add(FornecedorModel);
//                }

//                reader.Close();
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }

//            return lFornecedorModel;
//        }
//    }
//}
