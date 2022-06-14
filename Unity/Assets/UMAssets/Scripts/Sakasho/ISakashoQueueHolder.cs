using System;

public interface ISakashoQueueHolder
{
	// RVA: -1 Offset: -1 Slot: 0
	bool PushToQueue(Action action);
}
