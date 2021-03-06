﻿using Sitecore.Data.Items;
using System.Text.RegularExpressions;

namespace Elision.LookupSourceItems.Pipelines.ReplaceLookupSourceQueryTokens
{
    public class ReplaceItemFieldValueTokens : IReplaceLookupSourceQueryTokens
    {
        public void Process(ReplaceLookupSourceQueryTokensArgs args)
        {
            var tokenPattern = string.Concat(args.TokenPrefix, "ItemField:(?<fieldName>[^\\", args.TokenSuffix, "]+)", args.TokenSuffix);
            args.Query = Regex.Replace(args.Query, tokenPattern, x => GetFieldValue(args.ContextItem, x.Groups["fieldName"].Value), RegexOptions.IgnoreCase);
        }

        protected virtual string GetFieldValue(Item item, string fieldName)
        {
            return item[fieldName];
        }
    }
}
