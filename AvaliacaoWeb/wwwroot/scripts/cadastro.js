class Cadastro {
  static adicionarTelefone(evt) {
    var btn = $(evt.target).parent();
    var tel = btn.prev();
    var telclone = tel.clone();
    telclone.children().val('');
    telclone.appendTo(btn.parent());
    btn.clone().appendTo(btn.parent());

    $(evt.target).text('-');
    evt.target.onclick = Cadastro.removerTelefone;
  }
  static removerTelefone(evt) {
    var dvbtn = $(evt.target).parent();
    dvbtn.prev().remove();
    dvbtn.remove();
  }
  static novoCadastro() {
    $('form')[0].reset();
    var remover = $('#telefoneContainer').children();
    remover = remover.slice(0, remover.length - 2);
    remover.remove();
  }

  static dataFormat(evt) {
    var numero = evt.target.value.replace(/\D/g, "");
    numero = numero.substr(0, 8);
    if (numero.length != 8 || !moment(numero, "DDMMYYYY").isValid()) {
      $(evt.target).addClass("invalid");
    } else {
      if ($("#dezoitoAnos").length == 1) { //ruim: acessar objeto especifico
        if (moment(numero, "DDMMYYYY").add(18, 'y') > new Date()) {
          $(evt.target).addClass("invalid");
          $("#dezoitoAnos").show();
        } else {
          $(evt.target).removeClass("invalid");
          $("#dezoitoAnos").hide();
        }
      } else {
        $(evt.target).removeClass("invalid");
      }
    }
    var builder = [];
    if (numero.length <= 2) {
      builder.push(numero);
    } else {
      builder.push(numero.substr(0, 2));
      builder.push('/');
      if (numero.length <= 4) {
        builder.push(numero.substr(2));
      } else {
        builder.push(numero.substr(2, 2));
        builder.push('/');
        
        builder.push(numero.substr(4));
        
      }
    }
    evt.target.value = builder.join('');
  }

  static eValidoCPF(strCPF) {
    var soma;
    var resto;
    soma = 0;
    if (strCPF == "00000000000") return false;

    for (var i = 1; i <= 9; i++) soma = soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    resto = (soma * 10) % 11;

    if ((resto == 10) || (resto == 11)) resto = 0;
    if (resto != parseInt(strCPF.substring(9, 10))) return false;

    soma = 0;
    for (var i = 1; i <= 10; i++) soma = soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    resto = (soma * 10) % 11;

    if ((resto == 10) || (resto == 11)) resto = 0;
    return (resto == parseInt(strCPF.substring(10, 11)));
  }

  static cpfFormat(evt) {
    var numero = evt.target.value.replace(/\D/g, "");
    numero = numero.substr(0, 11);
    if (numero.length != 11 || !Cadastro.eValidoCPF(numero)) {
      $(evt.target).addClass("invalid");
    } else {
      $(evt.target).removeClass("invalid");
    }
    var builder = [];
    if (numero.length <= 3) {
      builder.push(numero);
    } else {
      builder.push(numero.substr(0, 3));
      builder.push('.');
      if (numero.length <= 6) {
        builder.push(numero.substr(3));
      } else {
        builder.push(numero.substr(3, 3));
        builder.push('.');
        if (numero.length <= 9) {
          builder.push(numero.substr(6));
        } else {
          builder.push(numero.substr(6, 3));
          builder.push('-');
          builder.push(numero.substr(9));
        }
      }
    }
    evt.target.value = builder.join('');
  }

  static telefoneFormat(evt) {
    
    var numero = evt.target.value.replace(/\D/g, "");
    if (numero.length != 11 && numero.length != 10 && numero != "") {
      $(evt.target).addClass("invalid");
    } else {
      $(evt.target).removeClass("invalid");
    }
    var builder = [];
    if (numero.length > 0) {
      builder.push('(');
      builder.push(numero.length > 2 ? numero.substr(0, 2) : numero);
      if (numero.length > 2) {
        numero = numero.substr(2);
        builder.push(') ');
        numero = numero.substr(0, 9);
        if (numero.length == 9) {
          builder.push(numero.substr(0, 5));
          builder.push('-');
          builder.push(numero.substr(5));
        } else {
          if (numero.length > 4) {
            builder.push(numero.substr(0, 4));
            builder.push('-');
            builder.push(numero.substr(4));
          } else {
            builder.push(numero);
          }
        }
      }
    }
    evt.target.value = builder.join('');
  }

  static formataRg(evt) {
    var numero = evt.target.value.replace(/\D/g, "");
    if (numero.length === 0) {
      $(evt.target).addClass("invalid");
    } else {
      $(evt.target).removeClass("invalid");
    }
    evt.target.value = numero;
  }

  static salvarCadastro() {
    if (!Cadastro.formularioCorreto()) {
      alert("Favor verificar as informações preenchidas");
      return;
    }
    var cadastro = Cadastro.obterValores();
    $('form :input').prop("disabled", true);
    
    var success = (msg) => {
      $('form :input').prop("disabled", false);
      if (msg) {
        alert(msg);
        return;
      }

      alert('Salvo');
      Cadastro.novoCadastro();
    }
    var fail = () => {
      $('form :input').prop("disabled", false);
      alert('Houve um erro no servidor, não foi possível salvar.');
    }

    $.ajax({
      type: "POST",
      url: "Cadastrar",
      data: JSON.stringify(cadastro),
      contentType: "application/json; charset=utf-8",
      dataType: "JSON",

      success: function (output) {
        success(output);
      },
      error: function () {
        fail();
      }
    });
  }

  static formularioCorreto() {
    if (!$("#CPFCliente").val() || $("#CPFCliente").hasClass('invalid')) {
      $("#CPFCliente").addClass('invalid');
      return false;
    }
    if (!$("#nomeCliente").val() || $("#nomeCliente").val().indexOf(" ") === -1) {
      $("#nomeCliente").addClass('invalid');
      return false;
    } else {
      $("#nomeCliente").removeClass('invalid');
    }
    if ($("#RGCliente").length == 1 && !$("#RGCliente").val()) {
      $("#RGCliente").addClass('invalid');
      return false;
    } else {
      $("#RGCliente").removeClass('invalid');
    }
    if (!$("#dataNasce").val() || $("#dataNasce").hasClass('invalid')) {
      $("#dataNasce").addClass('invalid');
      return false;
    }
    var temTelInvalido = false;
    $("input[name='telefone']").each((i, tel) => {
      if ($(tel).hasClass('invalid')) temTelInvalido = true;
    });
    if (temTelInvalido) return false;
    return true;
  }

  static obterValores() {
    var cadastro = {};
    cadastro.RG = ($("#RGCliente").val() || "").replace(/\D/g, "");
    cadastro.CPF = $("#CPFCliente").val().replace(/\D/g, "");
    cadastro.Nome = $("#nomeCliente").val();
    cadastro.DataNascimento = $("#dataNasce").val();
    cadastro.Telefones = [];
    $("input[name='telefone']").each((i, tel) => {
      var telNum = $(tel).val().replace(/\D/g, "");
      if (telNum) cadastro.Telefones.push(telNum);
    });
    return cadastro;
  }
}