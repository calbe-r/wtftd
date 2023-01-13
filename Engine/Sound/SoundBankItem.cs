using Microsoft.Xna.Framework.Audio;

namespace wtftd.Engine.Sound
{
    public class SoundBankItem
    {
        public SoundEffect Sound { get; private set; }
        public SoundAttributes Attributes { get; private set; }

        public SoundBankItem(SoundEffect sound, SoundAttributes attributes)
        {
            Sound = sound;
            Attributes = attributes;
        }
    }
}