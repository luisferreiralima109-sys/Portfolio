public enum QuestStatus
{
    NotStarted,
    InProgress,
    Completed,
    Failed
}

public class Quest
{
    public string Name { get; }
    public int RequiredKills { get; }
    public int CurrentKills { get; private set; }
    public QuestStatus Status { get; private set; }

    public event Action<Quest>? OnCompleted;

    public Quest(string name, int requiredKills)
    {
        Name = name;
        RequiredKills = requiredKills;
        Status = QuestStatus.NotStarted;
    }

    public void Start()
    {
        if (Status == QuestStatus.NotStarted)
            Status = QuestStatus.InProgress;
    }

    public void RegisterKill()
    {
        if (Status != QuestStatus.InProgress)
            return;

        CurrentKills++;

        if (CurrentKills >= RequiredKills)
        {
            Status = QuestStatus.Completed;
            OnCompleted?.Invoke(this);
        }
    }
}

public class QuestManager
{
    private readonly List<Quest> quests = new();

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
        quest.OnCompleted += HandleQuestCompleted;
    }

    private void HandleQuestCompleted(Quest quest)
    {
        Console.WriteLine($"Quest completed: {quest.Name}");
    }
}