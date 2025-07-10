namespace Interlude.Features.Play.HUD

open Percyqaz.Flux.UI
open Percyqaz.Flux.Graphics
open Prelude.Skins.HudLayouts
open Interlude.Features.Play

type SongInfo(config: HudConfig, state: PlayState) =
    inherit Container(NodeType.None)
    
    let title = state.ChartMeta.Title
    let artist = state.ChartMeta.Artist
    let difficulty_name = state.ChartMeta.DifficultyName
    
    let others =
        let positions : (Rect -> Rect) seq =
            [| (fun r -> r.SlicePercentT 0.6f); (fun r -> r.SlicePercentB 0.4f) |]
        let texts : (unit -> string) seq =
            seq {
                fun () -> artist
                fun () -> difficulty_name
            }
        Seq.zip positions texts
        |> Array.ofSeq
        
    let title_space, other_space = 0.4f, 0.55f

    override this.Draw() =
        let title_text_bounds = this.Bounds.SlicePercentT title_space
        let other_text_bounds = this.Bounds.SlicePercentB other_space 
        
        Text.fill_b(Style.font, title, title_text_bounds, Colors.text, Alignment.CENTER)
        for p, t in others do
            Text.fill_b(Style.font, t(), p other_text_bounds, Colors.text_subheading, Alignment.CENTER)
        