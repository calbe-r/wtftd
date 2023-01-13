using System;
using System.Collections.Generic;
using System.Linq;
using wtftd.Engine.Input;
using wtftd.Engine.Objects;
using wtftd.Engine.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using SpriteFontPlus;
using System.IO;

namespace wtftd.Engine.States
{
    public abstract class BaseGameState
    {
        protected bool _debug = false;
        protected bool _indestructible = false;

        private GraphicsDevice _graphicsDevice;
        protected int _viewportHeight;
        protected int _viewportWidth;
        protected SoundManager _soundManager = new SoundManager();

        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();
        private List<Texture2D> _loadedTextures = new List<Texture2D>();

        protected InputManager InputManager {get; set;}

        public void Initialize(GraphicsDevice graphicsDevice, int viewportWidth, int viewportHeight)
        {
            _graphicsDevice = graphicsDevice;
            _viewportHeight = viewportHeight;
            _viewportWidth = viewportWidth;

            SetInputManager();
        }

        public abstract void LoadContent();
        public abstract void HandleInput(GameTime gameTime);
        public abstract void UpdateGameState(GameTime gameTime);

        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        protected abstract void SetInputManager();

        public void UnloadContent()
        {
            foreach (Texture2D texture in _loadedTextures)
            {
                texture.Dispose();
            }
        }

        public void Update(GameTime gameTime) 
        {
            UpdateGameState(gameTime);
            _soundManager.PlaySoundtrack();
        }

        protected Texture2D LoadTexture(string textureName)
        {
           Texture2D temp = Texture2D.FromFile(_graphicsDevice, "Content/" + textureName);
           _loadedTextures.Add(temp);
           return temp;
        }

        protected SpriteFont LoadFont(string fontName)
        {
            var fontBakeResult = TtfFontBaker.Bake(File.ReadAllBytes("Content/" + fontName),
                25, 
                1024, 
                1024, 
                new[]
                {
                    CharacterRange.BasicLatin,
                    CharacterRange.Latin1Supplement,
                    CharacterRange.Latin1Supplement,
                    CharacterRange.Cyrillic
                }
            );

            SpriteFont font = fontBakeResult.CreateSpriteFont(_graphicsDevice);

            return font;
        }

        // NEED TO IMPLEMENT WITHOUT MGCB 
        //protected SoundEffect LoadSound(string soundName)
        //{
            //return _contentManager.Load<SoundEffect>(soundName);
        //}
 
        protected void NotifyEvent(BaseGameStateEvent gameEvent)
        {
            OnEventNotification?.Invoke(this, gameEvent);

            foreach (var gameObject in _gameObjects)
            {
                if (gameObject != null)
                    gameObject.OnNotify(gameEvent);
            }

            _soundManager.OnNotify(gameEvent);
        }

        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.Where(a => a != null).OrderBy(a => a.zIndex))
            {
                if (_debug)
                {
                    gameObject.RenderBoundingBoxes(spriteBatch);
                }

                gameObject.Render(spriteBatch);
            }
        }
    }
}