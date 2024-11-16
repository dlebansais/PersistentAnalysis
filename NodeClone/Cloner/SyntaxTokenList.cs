namespace NodeClone;

using System.Collections.Generic;
using System.Text;

public class SyntaxTokenList
{
    public SyntaxTokenList(List<SyntaxToken> tokens)
    {
        Tokens = tokens;
    }

    public List<SyntaxToken> Tokens { get; }

    public void AppendTo(StringBuilder stringBuilder)
    {
        string TokenString = string.Join(" ", Tokens.ConvertAll(Tokens => Tokens.Text));
        _ = stringBuilder.Append(TokenString).Append(" ");
    }
}
