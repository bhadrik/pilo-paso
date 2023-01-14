using UnityEngine;

public class SingletonBehaviour< TSelfType > : MonoBehaviour where TSelfType : MonoBehaviour
{
	private static TSelfType m_Instance = null;
	public static TSelfType Instance
	{
		get
		{
			if (m_Instance == null)
			{
				m_Instance = (TSelfType)FindObjectOfType(typeof(TSelfType));
				if (m_Instance == null)
				{
					m_Instance = (new GameObject(typeof(TSelfType).Name)).AddComponent<TSelfType>();
				}
			}
			return m_Instance;
		}
	}
}
