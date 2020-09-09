using System.Collections.Generic;

namespace ReMetalMax.Core {
    public class MapManager {
        public IMap CurrentMap { get; private set; }

        public Dictionary<int, int> MapSwitches { get ; private set; }

        public static readonly MapManager Instance = new MapManager();

        public void Load(IMap map) {
            this.CurrentMap = map;
        }

        public void Switch(IMap targetMap) {}
    }
}