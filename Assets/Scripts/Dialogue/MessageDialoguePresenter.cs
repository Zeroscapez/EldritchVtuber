using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Editor;
using UnityEngine.UI;

#nullable enable

public class MessageDialoguePresenter : DialoguePresenterBase
{
    [Header("Prefabs")]
    [SerializeField] SerializableDictionary<string, MessageObjectControl> messageObjects = new();
    [SerializeField] MessageObjectControl? messageObjectPrefab = null;

    [Header("Containers")]

    [SerializeField] RectTransform messageContainer;
    [SerializeField] Scrollbar scrollbar;

    [Header("Timing")]
    [SerializeField] float delayAfterLine = 1f;

    [SerializeField] float minimumTypingDelay = 0.5f;
    [SerializeField] float maximumTypingDelay = 3f;
    [SerializeField] float typingDelayPerCharacter = 0.05f;
    [SerializeField] bool showTypingIndicators = true;

    public override  YarnTask OnDialogueStartedAsync() => YarnTask.CompletedTask;
   

    public override YarnTask OnDialogueCompleteAsync() => YarnTask.CompletedTask;

    /// <summary>Presents a line using the configured text view.</summary>
    /// <inheritdoc cref="DialoguePresenterBase.RunLineAsync(LocalizedLine, LineCancellationToken)" path="/param"/>
    /// <inheritdoc cref="DialoguePresenterBase.RunLineAsync(LocalizedLine, LineCancellationToken)" path="/returns"/>
    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
       
        if(messageContainer == null)
        {
            Debug.LogWarning($"Missing message containter for '{line.Text.Text}'");
            return;
        }


        var prefab = messageObjectPrefab;

        if (prefab == null)
        {
            Debug.LogWarning($"Can't show line '{line.Text.Text}': no default bubble was set");
            return;
        }

        var message = Instantiate(prefab, messageContainer);
        message.ShowText(line.CharacterName,line.TextWithoutCharacterName.Text);

        await YarnTask.WaitUntilCanceled(token.HurryUpToken).SuppressCancellationThrow();
    }
    // Called by the Dialogue Runner to signal that a line of dialogue
    // should be shown to the player.
    //
    // If your presenter handles lines, it should take the 'line'
    // parameter and use the information inside it to present the content to
    // the player, in whatever way makes sense.
    //
    // Some useful information:
    // - The 'Text' property in 'line' contains the parsed, localised text
    //   of the line, including attributes and text.
    // - The 'TextWithoutCharacterName' property contains all of the text
    //   after the character name in the line (if present), and the
    //   'CharacterName' contains the character name (if present).
    // - The 'Asset' property contains whatever object was associated with
    //   this line, as provided by your Dialogue Runner's Line Provider.
    //
    // The LineCancellationToken contains information on whether the
    // Dialogue Runner wants this Presenter to hurry up its
    // presentation, or to advance to the next line. 
    //
    // - If 'token.IsHurryUpRequested' is true, that's a hint that your view
    //   should speed up its delivery of the line, if possible (for example,
    //   by displaying text faster). 
    // - If 'token.IsNextContentRequested' is true, that's an instruction that
    //   your view must end its presentation of the line as fast as possible
    //   (even if that means ending the delivery early.)
    //
    // The Dialogue Runner will wait for all Presenters to return from
    // this method before delivering new content.
    //
    // If your Dialogue Presenters doesn't need to handle lines, simply return
    // from this method immediately.



    public override async YarnTask<DialogueOption?> RunOptionsAsync(DialogueOption[] dialogueOptions, LineCancellationToken cancellationToken)
    {
        // Called by the Dialogue Runner to signal that options should be shown
        // to the player.
        //
        // If your Dialogue Presenter handles options, it should present them to the
        // player and await a selection. Once a choice has been made, it should
        // return the appropriate element from dialogueOptions.
        //
        // The LineCancellationToken contains information on whether the
        // Dialogue Runner wants this Presenter to hurry up its
        // presentation, or to advance to the next piece of content. 
        //
        // - If 'token.IsHurryUpRequested' is true, that's a hint that your view
        //   should speed up its delivery of the options, if possible (for example,
        //   by fading up text faster). 
        // - If 'token.IsNextContentRequested' is true, that's an instruction that
        //   your view must end handling options and return null as soon as possible.
        //
        // The Dialogue Runner will wait for all Dialogue Presenters to return from
        // this method before delivering new content.
        //
        // If your Dialogue Presenter doesn't need to handle options, simply
        // delete this method.

        return null;
    }
}
