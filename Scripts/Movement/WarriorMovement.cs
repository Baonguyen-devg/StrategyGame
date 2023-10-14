using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class WarriorMovement : BaseMovement
    {
        private readonly string TRIGGER_NAME = "Attack";
        private readonly string HORIZONTAL_NAME = "Horizontal";
        private readonly string VERTICAL_NAME = "Vertical";

        [SerializeField] private Animator animator;
        [SerializeField] private Transform tower;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float radius = 0.2f;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            this.tower = GameObject.Find("Tower").transform;
            this.animator = transform.parent.Find("Model").GetComponent<Animator>();
        }

        protected override void Move()
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, this.radius, this.layerMask);
            if (enemy != null)
            {
                this.LookToObject(enemy.transform);
                this.animator.SetBool(TRIGGER_NAME, true);
                return;
            }
            else this.animator.SetBool(TRIGGER_NAME, false);
            this.LookToObject(this.tower);
        }

        private void LookToObject(
            Transform obj
        ) {
            Vector3 direction = obj.position - this.transform.parent.position;
            direction.Normalize();
            this.animator.SetFloat(HORIZONTAL_NAME, direction.x);
            this.animator.SetFloat(VERTICAL_NAME, direction.y);
        }
    }
}