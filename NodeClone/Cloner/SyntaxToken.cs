namespace NodeClone;

using System.Text;

public class SyntaxToken
{
    public SyntaxToken(string text)
    {
        Text = text;
    }

    public string Text { get; }

    public void AppendTo(StringBuilder stringBuilder)
    {
        _ = stringBuilder.Append(Text).Append(" ");
    }
}
