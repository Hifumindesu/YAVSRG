namespace Interlude.Features.Play.HUD

open Percyqaz.Common
open Percyqaz.Flux.UI
open Prelude
open Prelude.Skins.HudLayouts
open Interlude.Features.Play

type SongInfo(config: HudConfig, state: PlayState) =
    inherit Container(NodeType.None)

    override this.Init(parent) =
        let text = state.ChartMeta.Title

        this |* Text(text)
            .Color(Colors.text_subheading)
            .Align(Alignment.CENTER)
        base.Init parent