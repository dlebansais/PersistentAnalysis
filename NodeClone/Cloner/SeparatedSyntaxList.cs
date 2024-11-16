namespace NodeClone;

using System.Collections.Generic;
using System.Text;

public class SeparatedSyntaxList<TClone> : List<TClone>
    where TClone : SyntaxNode
{
    public SeparatedSyntaxList(string separator)
    {
        Separator = separator;
    }

    public string Separator { get; }

    public void AppendTo(StringBuilder stringBuilder)
    {
        for (int i = 0; i < Count; i++)
        {
            if (i > 0)
                _ = stringBuilder.Append(Separator).Append(" ");

            this[i].AppendTo(stringBuilder);
        }
    }
}
