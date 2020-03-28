<div>
<h1>Set Name = {{ setname }}</h1>
<ul>
{% for category in quiz -%}
  <li>
    <div>Category {{ category.itemName }}</div>
{% for question in category -%}
{% if forloop.last == false -%}
    <ul>
      <li>
        <div>{{ question.question }}</div>
        <div class="options">
          <ul>
{% for option in question.options -%}
            <li>{{ option }}</li>
{% endfor -%}
          </ul>
        </div>
        <div>Answer: {{question.answer}}</div>
      </li>
    </ul>
{% endif -%}
{% endfor -%}
    </li>
{% endfor -%}
</ul>  
</div>
