namespace AvaliacaoCore.RegraDeNegocio.Validacoes
{
    public interface IValidacao<T>
    {
        ResultadoValidacao Validar(T model);
    }
}