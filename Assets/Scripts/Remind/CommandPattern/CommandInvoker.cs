using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private ICommand _command;
    //사용할 커맨드 설정
    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    
    //명령 실행
    public void ExecuteCommand()
    {
        _command?.Execute();
    }
    
    //명령 취소
    public void UndoCommand()
    {
        _command?.Undo();
    }
}