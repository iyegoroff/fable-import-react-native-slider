module Fable.Import.ReactNativeSlider

open Fable.Helpers.ReactNative
open Fable.Helpers.React
open Fable.Helpers.ReactNative.Props
open Fable.Core.JsInterop
open Fable.Import
open Fable.Core

module Props =

  type [<StringEnum; RequireQualifiedAccess>] AnimationType =
    | Spring
    | Timing

  type [<Pojo>] ThumbTouchSize =
    { width: float
      height: float }


  type SliderProps =
     /// Initial value of the slider. The value should be between minimumValue
     /// and maximumValue, which default to 0 and 1 respectively.
     /// Default value is 0.
     /// 
     /// *This is not a controlled component*, e.g. if you don't update
     /// the value, the component won't be reset to its inital value.
     | Value of float
     /// If true the user won't be able to move the slider.
     /// Default value is false.
     | Disabled of bool
     /// Initial minimum value of the slider. Default value is 0.
     | MinimumValue of float
     /// Initial maximum value of the slider. Default value is 1.
     | MaximumValue of float
     /// Step value of the slider. The value should be between 0 and
     /// (maximumValue - minimumValue). Default value is 0.
     | Step of float
     /// The color used for the track to the left of the button. Overrides the
     /// default blue gradient image.
     | MinimumTrackTintColor of string
     /// The color used for the track to the right of the button. Overrides the
     /// default blue gradient image.
     | MaximumTrackTintColor of string
     /// The color used for the thumb.
     | ThumbTintColor of string
     /// The size of the touch area that allows moving the thumb.
     /// The touch area has the same center has the visible thumb.
     /// This allows to have a visually small thumb while still allowing the user
     /// to move it easily.
     /// The default is {width: 40, height: 40}.
     | ThumbTouchSize of ThumbTouchSize
     /// Callback continuously called while the user is dragging the slider.
     | OnValueChange of (float -> unit)
     /// Callback called when the user starts changing the value (e.g. when
     /// the slider is pressed).
     | OnSlidingStart of (float -> unit)
     /// Callback called when the user finishes changing the value (e.g. when
     /// the slider is released).
     | OnSlidingComplete of (float -> unit)
     /// The style applied to the slider container.
     | Style of IStyle list
     /// The style applied to the track.
     | TrackStyle of IStyle list
     /// The style applied to the thumb.
     | ThumbStyle of IStyle list
     /// Sets an image for the thumb.
     | ThumbImage of IImageSource
     /// Set this to true to visually see the thumb touch rect in green.
     | DebugTouchArea of bool
     /// Set to true to animate values with default 'timing' animation type
     | AnimateTransitions of bool
     /// Custom Animation type. 'spring' or 'timing'.
     | AnimationType of AnimationType
     /// Used to configure the animation parameters.  These are the same parameters in the Animated library.
     | AnimationConfig of obj

open Props

let inline slider (props: SliderProps list): React.ReactElement =
  ofImport "default" "react-native-slider" (keyValueList CaseRules.LowerFirst props) []
