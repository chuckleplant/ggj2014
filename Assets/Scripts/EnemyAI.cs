using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float patrolSpeed = 3.5f;
	public float chaseSpeed = 6f;
	public float patrolWaitTime = 2f;
	public float chaseWaitTime = 5f;
	public float sightDistance = 20f;
	public Transform[] patrolWayPoints;

	private enum E_EnemyState {
		Patroling,
		Chasing
	}

	private NavMeshAgent nav;				// Reference to the nav mesh agent.
	private Transform player;				// Reference to the player's transform.
	private EyeManager eyeManager;			// Reference to the EyeManager
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private E_EnemyState state;

	void Awake() 
	{
		nav = this.GetComponent<NavMeshAgent>();
		state = E_EnemyState.Patroling;
	}
		
	bool PlayerDetected() {
		return Vector3.Distance(this.transform.position, player.position) < sightDistance;
	}

	void Update()
	{
		if (player == null) player = GameObject.FindGameObjectWithTag("PlayerNormal").transform;

		if (EyeManager.eyeState == EyeManager.E_EyeEquiped.Normal) {
			gameObject.renderer.material.color = Color.red;
		}
		else {
			gameObject.renderer.material.color = Color.green;
		}


		if (PlayerDetected() && EyeManager.eyeState != EyeManager.E_EyeEquiped.Kid) {
			// Si se ha detectado al player, perseguirlo
			Chasing();
		}
		else {
			// Si no, hacer la patrulla
			Patroling();
		}
	}

	void Chasing()
	{
		// Cambiar el estado a perseguir
		state = E_EnemyState.Chasing;

		// Modificar la velocidad a velocidad de persecución
		nav.speed = chaseSpeed;

		// Hacer que nuestro destino sea la posición del usuario 
		nav.destination = player.position;
	}

	void Patroling()
	{
		// Si nos tenemos que poner a patrullar, mirar si acabamos de dejar de ver al player
		if (state == E_EnemyState.Chasing) {

			// Incrementamos el timer de espera
			chaseTimer += Time.deltaTime;

			// Si ya hemos esperado suficiente
			if (chaseTimer >= chaseWaitTime) {
				// Volver a patrullar
				state = E_EnemyState.Patroling;

				// Reseteamos el timer
				chaseTimer = 0f;
			}
		}

		// Si definitivamente hay que patrullar
		if (state == E_EnemyState.Patroling) {
			//chaseTimer = 0f; --> creo que no hace falta, si se detectan bugs activar please

			// Modificar la velocidad a velocidad de patrulla
			nav.speed = patrolSpeed;

			Debug.Log(nav.remainingDistance < nav.stoppingDistance);
			Debug.Log(nav.remainingDistance);
			Debug.Log(nav.stoppingDistance);

			// Si hemos llegado al punto
			if (nav.remainingDistance < nav.stoppingDistance) {

				// Incrementamos el timer de espera (vamos a esperar un tiempo determinado en cada patrolWayPoint)
				patrolTimer += Time.deltaTime;

				// Si ya hemos esperado suficiente 
				if (patrolTimer >= patrolWaitTime) {
					// El enemigo debe ir ahora al siguiente patrolWayPoint
					if (wayPointIndex == patrolWayPoints.Length - 1) wayPointIndex = 0;
					else wayPointIndex++;

					// Reseteamos el timer (hemos cambiado nuestro destino)
					patrolTimer = 0f;
				}
			}
			// Si no reseteamos el timer
			else patrolTimer = 0f;

			nav.destination = patrolWayPoints[wayPointIndex].position;
		}
	}
}
