//using DevPrimeiraAula.Models;
//using System;
//using System.Data.SqlClient;


//namespace DevPrimeiraAula.Database
//{
//    internal class ClienteDB
//    {
//        private readonly SqlConnection connection;
//        //public ClienteDB()
//        //{
//        //    connection = ConexaoSqlServer.Conectar();
//        //}
//        internal void Inserir(ClienteModel clienteModel)
//        {
//            try
//            {
//                string queryString = "INSERT INTO Clientes VALUES (@CPF, @RG, @Nome, @Telefone, @Celular, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @DataInclusao, @DataAlteracao, @Ativo);";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@CPF", clienteModel.CPF);
//                command.Parameters.AddWithValue("@RG", clienteModel.RG);
//                command.Parameters.AddWithValue("@Nome", clienteModel.Nome);
//                command.Parameters.AddWithValue("@Telefone", clienteModel.Telefone ?? (object)DBNull.Value);

//                command.Parameters.AddWithValue("@Celular", clienteModel.Celular);
//                command.Parameters.AddWithValue("@Logradouro", clienteModel.Logradouro);
//                command.Parameters.AddWithValue("@Numero", clienteModel.Numero);

//                command.Parameters.AddWithValue("@Complemento", clienteModel.Complemento ?? (object)DBNull.Value);

//                command.Parameters.AddWithValue("@Cidade", clienteModel.Cidade);
//                command.Parameters.AddWithValue("@Estado", clienteModel.Estado);
//                command.Parameters.AddWithValue("@DataInclusao", DateTime.Now);
//                command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", clienteModel.Ativo);

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
//        internal void Alterar(ClienteModel clienteModelo)
//        {
//            try
//            {
//                string queryString = "UPDATE Clientes SET Ativo = @Ativo, RG = @RG, Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao WHERE CPF = @CPF";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@Cpf", clienteModelo.CPF);
//                command.Parameters.AddWithValue("@Rg", clienteModelo.RG);
//                command.Parameters.AddWithValue("@Nome", clienteModelo.Nome);
//                command.Parameters.AddWithValue("@Telefone", clienteModelo.Telefone ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Celular", clienteModelo.Celular);
//                command.Parameters.AddWithValue("@Logradouro", clienteModelo.Logradouro);
//                command.Parameters.AddWithValue("@Numero", clienteModelo.Numero);
//                command.Parameters.AddWithValue("@Complemento", clienteModelo.Complemento ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Cidade", clienteModelo.Cidade);
//                command.Parameters.AddWithValue("@Estado", clienteModelo.Estado);
//                command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", clienteModelo.Ativo);


//                //command.Parameters.AddWithValue("@Ativo", cbbAtivo.Text.ToUpper() == "SIM" ? true : false);  //Ternário
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {

//                throw new Exception("Erro ao alterar o cliente - " + ex.Message);
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }




//        }
//        internal ClienteModel ObterDadosCliente(string cpfDigitado)
//        {
//            ClienteModel modelo = new ClienteModel();
//            try
//            {
//                string queryString = "SELECT * FROM Clientes Where CPF = @CPF";
//                SqlCommand command = new SqlCommand(queryString, connection);
//                command.Parameters.AddWithValue("@CPF", cpfDigitado);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    modelo.CPF = reader["CPF"].ToString();
//                    modelo.RG = reader["RG"].ToString();
//                    modelo.Nome = reader["Nome"].ToString();
//                    modelo.Telefone = reader["Telefone"].ToString();
//                    modelo.Celular = reader["Celular"].ToString();
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

//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }
//            return modelo;












//        }
//        internal List<ClienteModel> ObterTodosClientes()
//        {
//            List<ClienteModel> lClienteModel = new List<ClienteModel>();

//            try
//            {
//                ClienteModel clienteModel;

//                string queryString = "SELECT * FROM Clientes";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                connection.Open();

//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    clienteModel = new ClienteModel();

//                    if (!reader["CPF"].Equals(DBNull.Value)) clienteModel.CPF = (String)reader["CPF"];
//                    if (!reader["RG"].Equals(DBNull.Value)) clienteModel.RG = (String)reader["RG"];
//                    if (!reader["Nome"].Equals(DBNull.Value)) clienteModel.Nome = (String)reader["Nome"];
//                    if (!reader["Telefone"].Equals(DBNull.Value)) clienteModel.Telefone = (String)reader["Telefone"];
//                    if (!reader["Celular"].Equals(DBNull.Value)) clienteModel.Celular = (String)reader["Celular"];
//                    if (!reader["Logradouro"].Equals(DBNull.Value)) clienteModel.Logradouro = (String)reader["Logradouro"];
//                    if (!reader["Numero"].Equals(DBNull.Value)) clienteModel.Numero = (String)reader["Numero"];
//                    if (!reader["Complemento"].Equals(DBNull.Value)) clienteModel.Complemento = (String)reader["Complemento"];
//                    if (!reader["Cidade"].Equals(DBNull.Value)) clienteModel.Cidade = (String)reader["Cidade"];
//                    if (!reader["Estado"].Equals(DBNull.Value)) clienteModel.Estado = (String)reader["Estado"];
//                    if (!reader["DataInclusao"].Equals(DBNull.Value)) clienteModel.DataInclusao = (DateTime)reader["DataInclusao"];
//                    if (!reader["DataAlteracao"].Equals(DBNull.Value)) clienteModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
//                    if (!reader["Ativo"].Equals(DBNull.Value)) clienteModel.Ativo = (bool)reader["Ativo"];

//                    lClienteModel.Add(clienteModel);
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

//            return lClienteModel;
//        }


//    }
//}
