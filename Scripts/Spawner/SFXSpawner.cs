using UnityEngine;

public class SFXSpawner : Spawner<string>
{
    private static SFXSpawner instance;
    public static SFXSpawner Instance => instance;

    [SerializeField] private AudioSource backgroundAudioObject;

    protected override void Awake()
    {
        base.Awake();
        SFXSpawner.instance = this;
        Transform backgroundAudio = transform.Find("Prefabs").Find("Background_Audio");
        this.backgroundAudioObject = backgroundAudio.GetComponent<AudioSource>();
    }

    public virtual void PlaySound(
        string soundName
    ) {
        Transform obj = this.GetObjectByType(soundName);
        if (obj == null) return;

        Transform objSpawn = this.GetPoolObject(obj);
        objSpawn.gameObject.SetActive(true);
        objSpawn.SetParent(this.holder);
        objSpawn.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayBackgroundAudio() => this.backgroundAudioObject.Play();
    public virtual void StopBackGroundAudio() => this.backgroundAudioObject.Stop();

    protected override bool CompareType(
        Transform p,
        string type
    ) => p.name.Equals(type);
}
