using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    enum TileType
    {
        NONE,  // Пусто
        GROUND, // Почва
        GRASS
    }

    class Tile : Transformable, Drawable {
        // Размер тайла по высоте и ширине
        public const int TILE_SIZE = 16;

        TileType type = TileType.GROUND;
        RectangleShape rectShape;

        public Tile(TileType type)
        {
            this.type = type;

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            switch (type) {
                case TileType.GROUND:
                    rectShape.Texture = Content.texTile0;
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Content.texTile1;
                    break;
            }

            rectShape.TextureRect = GetTextureRect(4,4);

        }

        public IntRect GetTextureRect(int i, int j) {
            int x = TILE_SIZE * i;
            int y = TILE_SIZE * j;
            return new IntRect(x, y, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states) {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}
