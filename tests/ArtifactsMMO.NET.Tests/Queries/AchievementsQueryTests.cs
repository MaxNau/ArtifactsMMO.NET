using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Queries;
using System.Reflection;

namespace ArtifactsMMO.NET.Tests.Queries
{
    public class AchievementsQueryTests
    {
        [Fact]
        public void Constructor_DefaultParameters_CreatesInstance()
        {
            var query = new AchievementsQuery();
            Assert.False(GetHasParameters(query));
            Assert.Null(query.Type);
            Assert.Null(query.Page);
            Assert.Null(query.Size);
        }

        [Fact]
        public void Constructor_WithParameters_CreatesInstance()
        {
            var type = AchievementType.CombatKill;
            int? page = 1;
            int? size = 10;
            var query = new AchievementsQuery(type, page, size);
            Assert.True(GetHasParameters(query));
            Assert.Equal(type, query.Type);
            Assert.Equal(page, query.Page);
            Assert.Equal(size, query.Size);
        }

        [Fact]
        public void ToQueryString_NoParameters_ReturnsEmptyString()
        {
            IQueryString query = new AchievementsQuery();
            var result = query.ToQueryString();
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ToQueryString_WithParameters_ReturnsQueryString()
        {
            var type = AchievementType.Gathering;
            int? page = 1;
            int? size = 10;
            IQueryString query = new AchievementsQuery(type, page, size);
            var result = query.ToQueryString();
            Assert.StartsWith("?", result);
            Assert.Contains($"type={type.ToString().ToLowerInvariant()}", result);
            Assert.Contains($"page={page}", result);
            Assert.Contains($"size={size}", result);
        }

        [Fact]
        public void ToQueryString_WithSomeExpliciteParameters_ReturnsQueryString()
        {
            var type = AchievementType.Gathering;
            int? size = 10;
            IQueryString query = new AchievementsQuery(type: type, size: size);
            var result = query.ToQueryString();
            Assert.StartsWith("?", result);
            Assert.Contains($"type={type.ToString().ToLowerInvariant()}", result);
            Assert.DoesNotContain("page=", result);
            Assert.Contains($"size={size}", result);
        }

        private static bool GetHasParameters(AchievementsQuery query)
        {
            var hasParametersProperty = typeof(AchievementsQuery)
                .GetProperty("HasParameters", BindingFlags.Instance | BindingFlags.NonPublic);

            if (hasParametersProperty != null)
            {
                var value = (bool?)hasParametersProperty.GetValue(query);
                return value ?? false;
            }

            return false;
        }
    }
}
