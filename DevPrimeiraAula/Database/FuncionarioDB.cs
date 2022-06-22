//using DevPrimeiraAula.Models;
//using System;
//using System.Data.SqlClient;


//namespace DevPrimeiraAula.Database
//{
//    internal class FuncionarioDB
//    {
//        private readonly SqlConnection connection;


//        public FuncionarioDB()
//        {
//            connection = ConexaoSqlServer.Conectar();
//        }

//        internal void Inserir(FuncionarioModel FuncionarioModelo)
//        {
//            try
//            {
//                string queryString = "INSERT INTO Funcionarios VALUES (@CPF, @RG, @Nome, @DataNascimento, @Telefone, @Celular, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @DataInclusao, @DataAlteracao, @Ativo)";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@CPF", FuncionarioModelo.CPF);
//                command.Parameters.AddWithValue("@RG", FuncionarioModelo.RG);
//                command.Parameters.AddWithValue("@Nome", FuncionarioModelo.Nome);
//                command.Parameters.AddWithValue("@DataNascimento", FuncionarioModelo.DataNascimento);
//                command.Parameters.AddWithValue("@Telefone", FuncionarioModelo.Telefone ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Celular", FuncionarioModelo.Celular);

//                command.Parameters.AddWithValue("@Logradouro", FuncionarioModelo.Logradouro);
//                command.Parameters.AddWithValue("@Numero", FuncionarioModelo.Numero);
//                command.Parameters.AddWithValue("@Complemento", FuncionarioModelo.Complemento ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Cidade", FuncionarioModelo.Cidade);
//                command.Parameters.AddWithValue("@Estado", FuncionarioModelo.Estado);
//                command.Parameters.AddWithValue("@DataInclusao", DateTime.Now);

//                command.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", FuncionarioModelo.Ativo);

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
//        internal void Alterar(FuncionarioModel funcionarioModelo)
//        {
//            try
//            {
//                string queryString = "UPDATE Funcionarios set RG = @RG, Nome = @Nome, DataNascimento = @DataNascimento, Telefone = @Telefone, Celular = @Celular, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao, Ativo = @Ativo WHERE CPF = @CPF";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("@CPF", funcionarioModelo.CPF);
//                command.Parameters.AddWithValue("@RG", funcionarioModelo.RG);
//                command.Parameters.AddWithValue("@Nome", funcionarioModelo.Nome);
//                command.Parameters.AddWithValue("@DataNascimento", funcionarioModelo.DataNascimento);
//                command.Parameters.AddWithValue("@Telefone", funcionarioModelo.Telefone ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Celular", funcionarioModelo.Celular);
//                command.Parameters.AddWithValue("@Logradouro", funcionarioModelo.Logradouro);
//                command.Parameters.AddWithValue("@Numero", funcionarioModelo.Numero);
//                command.Parameters.AddWithValue("@Complemento", funcionarioModelo.Complemento ?? (object)DBNull.Value);
//                command.Parameters.AddWithValue("@Cidade", funcionarioModelo.Cidade);
//                command.Parameters.AddWithValue("@Estado", funcionarioModelo.Estado);
//                command.Parameters.AddWithValue("@DataAlteracao",DateTime.Now);
//                command.Parameters.AddWithValue("@Ativo", funcionarioModelo.Ativo);

//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Erro ao atualizar o cliente - " + ex.Message);
//            }
//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }
//        }

//        internal FuncionarioModel ObterDadosFuncionario(string cpfDigitado)
//        {
//            FuncionarioModel modelo = new FuncionarioModel();

//            try
//            {
//                string queryString = "SELECT * FROM Funcionarios Where CPF = @CPF";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                command.Parameters.AddWithValue("CPF", cpfDigitado);

//                connection.Open();

//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    modelo.CPF = reader["CPF"].ToString();
//                    modelo.RG = reader["RG"].ToString();
//                    modelo.Nome = reader["Nome"].ToString();
//                    modelo.DataNascimento = Convert.ToDateTime( reader["DataNascimento"].ToString());
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
//            catch (Exception)
//            {
               
//            }

//            finally
//            {
//                connection.Close();
//                connection.Dispose();
//            }
//            return modelo;



//        }

//        internal List<FuncionarioModel> ObterTodosFuncionarios()
//        {
//            List<FuncionarioModel> lFuncionarioModel = new List<FuncionarioModel>();

//            try
//            {
//                FuncionarioModel FuncionarioModel;

//                string queryString = "SELECT * FROM Funcionarios";
//                SqlCommand command = new SqlCommand(queryString, connection);

//                connection.Open();

//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    FuncionarioModel = new FuncionarioModel();

//                    if (!reader["CPF"].Equals(DBNull.Value)) FuncionarioModel.CPF = (String)reader["CPF"];
//                    if (!reader["RG"].Equals(DBNull.Value)) FuncionarioModel.RG = (String)reader["RG"];
//                    if (!reader["Nome"].Equals(DBNull.Value)) FuncionarioModel.Nome = (String)reader["Nome"];
//                    if (!reader["Telefone"].Equals(DBNull.Value)) FuncionarioModel.Telefone = (String)reader["Telefone"];
//                    if (!reader["Celular"].Equals(DBNull.Value)) FuncionarioModel.Celular = (String)reader["Celular"];
//                    if (!reader["Logradouro"].Equals(DBNull.Value)) FuncionarioModel.Logradouro = (String)reader["Logradouro"];
//                    if (!reader["Numero"].Equals(DBNull.Value)) FuncionarioModel.Numero = (String)reader["Numero"];
//                    if (!reader["Complemento"].Equals(DBNull.Value)) FuncionarioModel.Complemento = (String)reader["Complemento"];
//                    if (!reader["Cidade"].Equals(DBNull.Value)) FuncionarioModel.Cidade = (String)reader["Cidade"];
//                    if (!reader["Estado"].Equals(DBNull.Value)) FuncionarioModel.Estado = (String)reader["Estado"];
//                    if (!reader["DataInclusao"].Equals(DBNull.Value)) FuncionarioModel.DataInclusao = (DateTime)reader["DataInclusao"];
//                    if (!reader["DataAlteracao"].Equals(DBNull.Value)) FuncionarioModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
//                    if (!reader["Ativo"].Equals(DBNull.Value)) FuncionarioModel.Ativo = (bool)reader["Ativo"];

//                    lFuncionarioModel.Add(FuncionarioModel
//                        );
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

//            return lFuncionarioModel;
//        }
//    }
//}


