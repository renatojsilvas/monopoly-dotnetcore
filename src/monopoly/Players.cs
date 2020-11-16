using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace monopoly
{
    public class Players : IEnumerable<Player>
    {
        private Dictionary<Player, bool> activePlayers = new Dictionary<Player, bool>();

        public Players(List<Player> players)
        {
            players.ForEach(p => this.activePlayers.Add(p, true));
        }

        public int NumberOfActivePlayers { get => this.activePlayers.Count(p => p.Value); }

        public void Remove(Player player)
        {
            this.activePlayers[player] = false;
        }

        public IEnumerator<Player> GetEnumerator()
        {
            foreach (var p in activePlayers.Keys.ToList())
            {
                if (activePlayers[p])
                {
                    yield return p;
                }                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
