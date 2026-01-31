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
  

}
