namespace Interlude.Features.Play.HUD

open Percyqaz.Flux.UI
open Percyqaz.Flux.Graphics
open Prelude.Skins.HudLayouts
open Interlude.Features.Play

type SongInfo(config: HudConfig, state: PlayState) =
    inherit Container(NodeType.None)

    override this.Draw() =
        let title = state.ChartMeta.Title
        let artist = state.ChartMeta.Artist
        let text_boundsT = this.Bounds.SlicePercentT 0.5f
        let text_boundsB = this.Bounds.SlicePercentB 0.5f
        
        Text.fill_b(Style.font, title, text_boundsT, Colors.text, Alignment.CENTER)
        Text.fill_b(Style.font, artist, text_boundsB, Colors.text_subheading, Alignment.CENTER)
        