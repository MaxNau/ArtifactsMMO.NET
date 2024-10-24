using System;
using System.Text;

namespace ArtifactsMMO.NET.Internal
{
    internal sealed class QueryStringBuilder
    {
        private StringBuilder _queryBuilder;

        public QueryStringBuilder()
        {
            _queryBuilder = new StringBuilder();
        }

        public QueryStringBuilder AddParameter(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(key))
            {
                if (_queryBuilder.Length == 0)
                {
                    _queryBuilder.Append("?");
                }
                else
                {
                    _queryBuilder.Append("&");
                }
                _queryBuilder.Append($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");
            }
            return this;
        }

        public override string ToString()
        {
            return _queryBuilder.ToString();
        }
    }
}
