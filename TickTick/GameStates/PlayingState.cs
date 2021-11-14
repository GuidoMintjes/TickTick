using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class PlayingState : GameState, IPlayingState
{
    Level level;
    Button quitButton;
    SpriteGameObject completedOverlay, gameOverOverlay;

    public PlayingState()
    {
        // add a "quit" button
        //quitButton = new Button("Sprites/UI/spr_button_quit", 1);
        //quitButton.LocalPosition = new Vector2(TickTick.window.X, TickTick.window.Y / 25);
        //gameObjects.AddChild(quitButton);

        // Removed quit button: TODO: add functionality ==> 'ESC' = 'back'

        // add overlay images
        completedOverlay = AddOverlay("Sprites/UI/spr_welldone");
        gameOverOverlay = AddOverlay("Sprites/UI/spr_gameover");

        // These are part of the UI, even though they are not always shown, so set them fixed to the screen
        //  instead of moving along with the camera by setting their UI bool to be true
        completedOverlay.SetScreenSpace(true);
        gameOverOverlay.SetScreenSpace(true);
    }

    SpriteGameObject AddOverlay(string spriteName)
    {
        SpriteGameObject result = new SpriteGameObject(spriteName, 1);
        result.SetOriginToCenter();
        result.LocalPosition = new Vector2(TickTick.window.X / 2, TickTick.window.Y / 2);
        gameObjects.AddChild(result);
        return result;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (level != null)
        {
            // if the player character has died, allow the player to reset the level
            if (gameOverOverlay.Visible)
            {
                if (inputHelper.KeyPressed(Keys.Space))
                    level.Reset();
            }
            
            // if the level has been completed, pressing the spacebar should send the player to the next level
            else if (completedOverlay.Visible)
            {
                if (inputHelper.KeyPressed(Keys.Space))
                    ExtendedGameWithLevels.GoToNextLevel(level.LevelIndex);
            }

            // otherwise, update the level itself, and check for button presses
            else 
            {
                level.HandleInput(inputHelper);

                if (inputHelper.KeyPressed(Keys.Escape))
                    ExtendedGame.GameStateManager.SwitchTo(ExtendedGameWithLevels.StateName_LevelSelect);
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (level != null)
            level.Update(gameTime);

        // show or hide the "game over" image
        gameOverOverlay.Visible = !level.Player.IsAlive;

    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
        if (level != null)
            level.Draw(gameTime, spriteBatch);
    }

    public void LoadLevel(int levelIndex)
    {
        level = new Level(levelIndex, ExtendedGame.ContentRootDirectory + "/Levels/level" + levelIndex + ".txt");

        //quitButton.LocalPosition = new Vector2(TickTick.window.X, TickTick.window.Y / 25);
        completedOverlay.LocalPosition = new Vector2(TickTick.window.X / 2, TickTick.window.Y / 3);
        gameOverOverlay.LocalPosition = new Vector2(TickTick.window.X / 2, TickTick.window.Y / 3);

        // hide the overlay images
        completedOverlay.Visible = false;
        gameOverOverlay.Visible = false;
    }

    public void LevelCompleted(int levelIndex)
    {
        // show an overlay image
        completedOverlay.Visible = true;


        // play a sound
        ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_won");

        // mark the level as solved, and unlock the next level
        ExtendedGameWithLevels.MarkLevelAsSolved(levelIndex);

    }
}