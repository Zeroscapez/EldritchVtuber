using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Attributes;

#nullable enable

public class ChatDialogueControl : DialoguePresenterBase
{
    [Header("Prefabs")]
    [SerializeField] ChatBoxControl? chatBoxPrefab = null;

    [Header("Containers")]

    [SerializeField] RectTransform? chatContainer = null;

    [Group("Automatically Advance Dialogue")]
    public bool autoAdvance = false;

    [Group("Automatically Advance Dialogue")]
    [ShowIf(nameof(autoAdvance))]
    [Label("Delay Before Advancing")]
    public float autoAdvanceDelay = 1f;


    public override YarnTask OnDialogueStartedAsync() => YarnTask.CompletedTask;
    
      

    public override YarnTask OnDialogueCompleteAsync() => YarnTask.CompletedTask;
    

    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
        if (chatContainer == null)
        {
            Debug.LogWarning($"Missing message containter for '{line.Text.Text}'");
            return;
        }

        var prefab = chatBoxPrefab;

        if (prefab == null)
        {
            Debug.LogWarning($"Can't show line '{line.Text.Text}': no default bubble was set");
            return;
        }

        
        var chat = Instantiate(prefab, chatContainer);
        chat.ShowText(line.CharacterName, line.TextWithoutCharacterName.Text);

        if (autoAdvance)
        {
            await YarnTask.Delay(
                (int)(autoAdvanceDelay * 1000),
                token.HurryUpToken
            ).SuppressCancellationThrow();
        }
        else
        {
            await YarnTask.WaitUntilCanceled(token.HurryUpToken)
                .SuppressCancellationThrow();
        }

        return;



    }
  

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
