using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ResumeService.EntryModels
{
    public class GithubRepositoryEntry
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

    public class GithubRepositoryEntries : IEnumerable
    {
        public List<GithubRepositoryEntry> repos = new List<GithubRepositoryEntry>();

        public void AddGithubRepo(GithubRepositoryEntry repo)
        {
            repos.Add(repo);
        }

        public void AddGithubRepos(GithubRepositoryEntry[] repo)
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
        private GithubRepositoryEntry[] Repos;
        private int position = -1;

        public GithubReposEnum(GithubRepositoryEntry[] repos)
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

        public GithubRepositoryEntry Current
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

        public GithubRepositoryEntry this[int index]
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
