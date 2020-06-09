using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ResumeService.Models
{
    public class GithubRepo
    {
        [JsonPropertyName("id")]
        public int RepoID { get; set; }

        [JsonPropertyName("name")]
        public string RepoName { get; set; }

        [JsonPropertyName("html_url")]
        public string Link { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("clone_url")] 
        public string GitRequest { get; set; }

    }

    public class GithubRepos : IEnumerable
    {
        public List<GithubRepo> repos = new List<GithubRepo>();

        public void AddGithubRepo(GithubRepo repo)
        {
            repos.Add(repo);
        }

        public void AddGithubRepos(GithubRepo[] repo)
        {
            repos.AddRange(repo);
        }

        public IEnumerator GetEnumerator()
        {
            return new GithubReposEnum(repos.ToArray());
        }
    }

    public class GithubReposEnum : IEnumerator
    {
        private GithubRepo[] Repos;
        private int position = -1;

        public GithubReposEnum(GithubRepo[] repos)
        {
            Repos = repos;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public GithubRepo Current
        {
            get
            {
                try
                {
                    return Repos[position];
                }
                catch
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public GithubRepo this[int index]
        {
            get
            {
                return Repos[index];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < Repos.Length);
        }

        public void Reset()
        {
            position = -1;
        }

    }
}
