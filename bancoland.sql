classe p�blica Contexto: IDisposable
{
hospedeiro string = Serv.Host; // "HOLODEK-ACER1 \\ HOLODEK_ACER", "DESKTOP-LC33EUU", "192.168.1.73";
string de banco = Serv.Banco; // "NewSistema";
cadeia = utilizador Serv.User; // "sa";
corda pwd = Serv.Senha; // "12345"; "Xt90swi"; //
seq��ncia de polling = Serv.Pollin; // "false";

// host string = "DESKTOP-LC33EUU"; // "192.168.1.73";
// String banco = "utyumcombr_";
// string user = "sa";
// String pwd = "12345"; // "xt90swi"; //
// seq��ncia de polling = "false";

// String host = "192.168.1.98"; // "192.168.1.73";
// String banco = "prontuario";
// string user = "sa";
// String pwd = "xt90swi"; // "xt90swi"; //
// seq��ncia de polling = "true";
readonly p�blico SqlConnection minhaConexao;

Contexto p�blica ()
{
minhaConexao = new SqlConnection ( "Data Source =" + host + "; Initial Catalog = "+ Banco +"; uid = "+ usu�rio +"; Password = "+ pwd +"; MultipleActiveResultSets = true; Pooling = "+ vota��o +"; Min Pool Size = 0; Max Pool Size = 250; Connect Timeout = 30; ");
// minhaConexao = new SqlConnection ( "Data Source = DESKTOP-LC33EUU; Initial Catalog = NewSistema; uid = sa; Password = 12345; MultipleActiveResultSets = true; Pooling = true;");
experimentar
{
minhaConexao.Open ();
}
prendedor (excep��o ex)
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
prendedor (excep��o ex)
{
Lay1.Cod_Erro = "SQL";
jogue ex;
}
}

p�blica SqlDataReader ExecutaComandoComRetorno (string strQuery)
{
utilizando (var cmdComando = new SqlCommand (strQuery, minhaConexao))
{
experimentar
{
regresso cmdComando.ExecuteReader ();
}
prendedor (excep��o ex)
{
Lay1.Cod_Erro = "SQL";
jogue ex;
}
}
}

// M�todo - Fechar Conexao
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

Exce��o p�blica UltimaException {get; conjunto; }

msg public string {get; conjunto; }

EVENT_LOG_NAME public string {get; conjunto; }

[SerializableAttribute]
[ComVisibleAttribute (verdadeiro)]
NullReferenceException classe p�blica: SystemException
{

}

}


