package com.lab;

import lombok.*;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

//Z.4.2.5
//Z.4.2.2
//Z.4.2.1
@Getter
@Setter
@Entity
@Table(name = "users", indexes = @Index(name = "multiIndex1", columnList = "id, login"))
@AllArgsConstructor
@NoArgsConstructor
@ToString
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(unique = true)
    private String login;
    private String password;
    @Column(nullable = false)
    private String firstName;
    @Column(nullable = false)
    private String lastName;

    //Z.4.2.4
    @Enumerated(EnumType.STRING)
    private Sex sex;

    //Z.4.4.3
    //Wykorzystałem ManyToMany zamiast OneToMany aby umożliwić użytkownikom współdzielenie roli
    @ManyToMany(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    //Z.4.4.1
    private final List<Role> roles = new ArrayList<>();
    @Lob
    @Column(columnDefinition = "MEDIUMBLOB")
    private byte[] image = null;

    public User(Long id, String login, String password, String firstName, String lastName, Sex sex) {
        this.id = id;
        this.login = login;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.sex = sex;
    }


    //Z.4.4.2
    public boolean addRole(Role role) {
        return roles.add(role);
    }


    public enum Sex {
        MALE,
        FEMALE
    }
}
