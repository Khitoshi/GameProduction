using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface CharacterStateBase
{
    public void Enter();
    public void Excute();
    public void Exit();

}

public class EnemyStateBase: MonoBehaviour
{
    public EnemyStateBase() { }

    public virtual void Enter() { }
    public virtual void Excute() { }
    public virtual void Exit() { }

}



