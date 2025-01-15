using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 커맨드 패턴 -> 목표 : 요청(명령)과 실행의 세부사항을 분리하여 명령을 캡슐화.
//요청(Action)을 객체로 캡슐화하여 요청을 매핑하고 실행하는 구조를 설계하는 패턴
/*
 아래 세 가지 핵심 컴포넌트가 필요.
    Command 인터페이스/추상 클래스: 행동을 캡슐화합니다. (단일 명령의 실행 및 취소 메서드를 포함)
    Concrete Command 구현체: 실제 작업 명령(예: 움직임)과 취소(Undo) 구현을 포함.
    Invoker(명령 호출자): 명령을 큐에 저장하거나 조건에 따라 실행/취소를 관리.
    
    해당 코드랑 CommandInvoker랑 같이 엮인다.
    
    커맨드 패턴은 주로 명령(Command), 수신자(Receiver), 명령 호출자(Invoker)로 구성된다.
    Command는 실제로 무엇을 할지를 정의하는 캡슐화된 명령 객체.
    Receiver는 명령에 따라 작업을 실행하는 실제 대상 -> ex) GameObject의 transform
    Invoker는 Command 객체를 실행하거나 취소하는 역할을 수행. -> 실행해야 할 명령을 저장, 입력에 반응해 명령을 실행.
    Invoker의 역할은 Command와 Receiver사이의 중개자 역할을 함.
    
 */

public interface ICommand
{
    void Execute();
    void Undo();
}

public class MoveCommand : ICommand
{
    private Transform _transform;
    private Vector3 _PrevPos;
    
    //생성자 - 이동할 객체의 transform을 인자로 받음.
    public MoveCommand(Transform transform)
    {
        _transform = transform;
    }
    public void Execute()
    {
        //이동 전 위치 저장
        _PrevPos = _transform.position;
        // 앞으로 이동
        _transform.Translate(Vector3.forward * 10);
    }

    public void Undo()
    {
        //이전 위치로 되돌림
        _transform.position = _PrevPos;
    }
}

public class CommandPattern : MonoBehaviour
{
    private CommandInvoker _command;
    private Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        _command = gameObject.AddComponent<CommandInvoker>();
        _transform = GetComponent<Transform>();
        //이동 대상 설정(여기서는 현재 객체의 transform)
        _transform = transform;
        //이동 명령 설정
        _command.SetCommand(new MoveCommand(_transform));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _command.ExecuteCommand();
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            _command.UndoCommand();
        }
    }
}
