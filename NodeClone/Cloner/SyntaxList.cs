namespace NodeClone;

using System.Collections.Generic;
using System.Text;

public class SyntaxList<TClone> : List<TClone>
    where TClone : SyntaxNode
{
    public void AppendTo(StringBuilder stringBuilder)
    {
        for (int i = 0; i < Count; i++)
        {
            if (i > 0)
                _ = stringBuilder.Append(" ");

            this[i].AppendTo(stringBuilder);
        }
    }
}
