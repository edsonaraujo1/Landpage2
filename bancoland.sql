classe pública Contexto: IDisposable
{
hospedeiro string = Serv.Host; // "HOLODEK-ACER1 \\ HOLODEK_ACER", "DESKTOP-LC33EUU", "192.168.1.73";
string de banco = Serv.Banco; // "NewSistema";
cadeia = utilizador Serv.User; // "sa";
corda pwd = Serv.Senha; // "12345"; "Xt90swi"; //
seqüência de polling = Serv.Pollin; // "false";

// host string = "DESKTOP-LC33EUU"; // "192.168.1.73";
// String banco = "utyumcombr_";
// string user = "sa";
// String pwd = "12345"; // "xt90swi"; //
// seqüência de polling = "false";

// String host = "192.168.1.98"; // "192.168.1.73";
// String banco = "prontuario";
// string user = "sa";
// String pwd = "xt90swi"; // "xt90swi"; //
// seqüência de polling = "true";
readonly público SqlConnection minhaConexao;

Contexto pública ()
{
minhaConexao = new SqlConnection ( "Data Source =" + host + "; Initial Catalog = "+ Banco +"; uid = "+ usuário +"; Password = "+ pwd +"; MultipleActiveResultSets = true; Pooling = "+ votação +"; Min Pool Size = 0; Max Pool Size = 250; Connect Timeout = 30; ");
// minhaConexao = new SqlConnection ( "Data Source = DESKTOP-LC33EUU; Initial Catalog = NewSistema; uid = sa; Password = 12345; MultipleActiveResultSets = true; Pooling = true;");
experimentar
{
minhaConexao.Open ();
}
prendedor (excepção ex)
{
Lay1.Cod_Erro = "SQL";
jogue ex;
}
}
ExecutaComando public void (strQuery string)
{
var cmdComando = new SqlCommand
{
CommandText = strQuery,
CommandType = CommandType.Text,
Connection = minhaConexao
};
experimentar
{
cmdComando.ExecuteNonQuery ();
}
prendedor (excepção ex)
{
Lay1.Cod_Erro = "SQL";
jogue ex;
}
}

pública SqlDataReader ExecutaComandoComRetorno (string strQuery)
{
utilizando (var cmdComando = new SqlCommand (strQuery, minhaConexao))
{
experimentar
{
regresso cmdComando.ExecuteReader ();
}
prendedor (excepção ex)
{
Lay1.Cod_Erro = "SQL";
jogue ex;
}
}
}

// Método - Fechar Conexao
public void FecharConexao ()
{
minhaConexao.Close ();
}

public void Dispose ()
{
if (minhaConexao! = null && minhaConexao.State == ConnectionState.Open)
{
minhaConexao.Close ();
}
if (minhaConexao! = null)
{
minhaConexao.Dispose ();
}
}

public void Open ()
{
se (minhaConexao.State == ConnectionState.Closed)
{
minhaConexao.Open ();
}
}

Fechar public void ()
{
se (minhaConexao.State == ConnectionState.Open)
{
minhaConexao.Close ();
}
}

Exceção pública UltimaException {get; conjunto; }

msg public string {get; conjunto; }

EVENT_LOG_NAME public string {get; conjunto; }

[SerializableAttribute]
[ComVisibleAttribute (verdadeiro)]
NullReferenceException classe pública: SystemException
{

}

}


